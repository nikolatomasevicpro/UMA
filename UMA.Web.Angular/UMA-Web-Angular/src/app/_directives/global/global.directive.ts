import { Directive, ElementRef, Input, OnInit, HostBinding } from '@angular/core';
import { InternationalizationService } from 'src/app/_services/_base/internationalization/internationalization.service';

@Directive({
  selector: '[appGlobal]'
})
export class GlobalDirective implements OnInit {
  @Input() appGlobal: string;
  @HostBinding('innerHTML') content;

  constructor(private el: ElementRef,
              private international: InternationalizationService,
    ) { }

  ngOnInit() {
      this.content = this.international.translate(this.appGlobal);
  }
}
