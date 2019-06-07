import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfigurationService } from '../config/configuration.service';
import { NotificationLevel } from 'src/app/_models/enums/NotificationLevel.enum';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  constructor(
    private conf: ConfigurationService,
    private toastr: ToastrService) {
     }

  critical(message: string, title: string,
           timeout: number = this.conf.config.notification.defaultShowTimeout, ignoreNotificationLevel: boolean = false) {
      if (ignoreNotificationLevel || this.conf.config.notificationLevel >= NotificationLevel.critical) {
      this.toastr.show(message, title, { timeOut: timeout });
    }
  }

  error(message: string, title: string,
        timeout: number = this.conf.config.notification.defaultErrorTimeout, ignoreNotificationLevel: boolean = false) {
      if (ignoreNotificationLevel || this.conf.config.notificationLevel >= NotificationLevel.error) {
      this.toastr.error(message, title, { timeOut: timeout });
    }
  }

  warn(message: string, title: string,
       timeout: number = this.conf.config.notification.defaultWarnTimeout, ignoreNotificationLevel: boolean = false) {
      if (ignoreNotificationLevel || this.conf.config.notificationLevel >= NotificationLevel.warning) {
      this.toastr.warning(message, title, { timeOut: timeout });
    }
  }

  info(message: string, title: string,
       timeout: number = this.conf.config.notification.defaultInfoTimeout, ignoreNotificationLevel: boolean = false) {
      if (ignoreNotificationLevel || this.conf.config.notificationLevel >= NotificationLevel.information) {
      this.toastr.info(message, title, { timeOut: timeout });
    }
  }

  success(message: string, title: string,
          timeout: number = this.conf.config.notification.defaultSuccessTimeout, ignoreNotificationLevel: boolean = false) {
      if (ignoreNotificationLevel || this.conf.config.notificationLevel >= NotificationLevel.debug) {
      this.toastr.success(message, title, { timeOut: timeout });
    }
  }

  trace(message: string, title: string,
        timeout: number = this.conf.config.notification.defaultInfoTimeout, ignoreNotificationLevel: boolean = false) {
      if (ignoreNotificationLevel || this.conf.config.notificationLevel >= NotificationLevel.trace) {
      this.toastr.show(message, title, { timeOut: timeout });
    }
  }
}
