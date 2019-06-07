import { Directive, Input, OnInit, HostBinding } from '@angular/core';
import { InternationalizationService } from 'src/app/_services/_base/internationalization/internationalization.service';
import { NotificationService } from 'src/app/_services/_base/notification/notification.service';

@Directive({
  selector: '[appGlobal]'
})
export class GlobalDirective implements OnInit {
  @Input() appGlobal: string;
  @HostBinding('innerHTML') content;

  constructor(
    private international: InternationalizationService,
    private notif: NotificationService) { }

  ngOnInit() {
    this.translate();
    this.international.language.subscribe(language => {
      this.translate();
    });
  }

  private translate() {
    this.content = this.international.translate(this.appGlobal) || this.international.translate('Error_Missing_Translation');
    this.notif.trace('Translated "' + this.appGlobal + '" to "' + this.content + '"', 'Global :');
  }
}
