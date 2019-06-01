import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services/authentication/authentication.service';
import { SessionService } from 'src/app/_services/_base/session/session.service';
import { MustMatch } from 'src/app/_helpers/validators/mustmatch.validator';
import { first } from 'rxjs/operators';
import { NotificationService } from 'src/app/_services/_base/notification/notification.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private sessionService: SessionService,
    private notifications: NotificationService
  ) {
      if (this.sessionService.isAuthentified) {
        this.router.navigate(['/']);
      }
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required/*, Validators.minLength(12)*/],
      confirmPassword: ['', Validators.required]
    }, {
      validator: MustMatch('password', 'confirmPassword')
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      this.notifications.error('Form is invalid', 'Register :');
      return;
    }

    const login = this.f.userName.value;
    const password = this.f.password.value;
    this.loading = true;
    this.authenticationService.register({ login, password})
        .pipe(first())
        .subscribe(
            response => {
              if (response.result) {
                this.notifications.success('User ' + login + ' successfully created', 'Register :');
                this.authenticationService.login({ login, password})
                .subscribe(subResponse => {
                  if (this.sessionService.isAuthentified) {
                    this.router.navigate([this.returnUrl]);
                  } else {
                    this.router.navigate(['/login']);
                  }
                });
              } else {
                this.router.navigate(['/login']);
              }
            },
            error => {
                this.loading = false;
            });
  }
}
