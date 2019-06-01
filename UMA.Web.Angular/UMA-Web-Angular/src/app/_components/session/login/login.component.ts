import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AuthenticationService } from '../../../_services/authentication/authentication.service';
import { SessionService } from 'src/app/_services/_base/session/session.service';
import { NotificationService } from 'src/app/_services/_base/notification/notification.service';

@Component({templateUrl: 'login.component.html'})
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
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
        // redirect to home if already logged in
        if (this.sessionService.isAuthentified) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', [Validators.required]],
        });

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
    }

    // convenience getter for easy access to form fields
    get f() { return this.loginForm.controls; }

    onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }

        this.loading = true;
        this.authenticationService.login({ login: this.f.username.value, password: this.f.password.value})
            .pipe(first())
            .subscribe(
                data => {
                  if (this.sessionService.isAuthentified) {
                    this.notifications.success('Welcome back ' + this.f.username.value + '!', 'Login :');
                    this.router.navigate([this.returnUrl]);
                  } else {
                    this.loading = false;
                    this.router.navigate(['/login']);
                  }
                },
                error => {
                    this.loading = false;
                });
    }
}
