import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfigurationService } from '../config/configuration.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  constructor(
    private conf: ConfigurationService,
    private toastr: ToastrService) { }

  show(message: string, title: string, timeout: number = this.conf.config.notification.defaultShowTimeout) {
    this.toastr.show(message, title, { timeOut: timeout });
  }

  warn(message: string, title: string, timeout: number = this.conf.config.notification.defaultWarnTimeout) {
    this.toastr.warning(message, title, { timeOut: timeout });
  }

  success(message: string, title: string, timeout: number = this.conf.config.notification.defaultSuccessTimeout) {
    this.toastr.success(message, title, { timeOut: timeout });
  }

  error(message: string, title: string, timeout: number = this.conf.config.notification.defaultErrorTimeout) {
    this.toastr.error(message, title, { timeOut: timeout });
  }

  info(message: string, title: string, timeout: number = this.conf.config.notification.defaultInfoTimeout) {
    this.toastr.info(message, title, { timeOut: timeout });
  }
}
