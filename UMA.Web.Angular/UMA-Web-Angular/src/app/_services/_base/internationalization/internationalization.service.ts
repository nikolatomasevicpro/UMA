import { Injectable } from '@angular/core';
import { Dictionary } from 'src/app/_models/internationalization/Dictionary';
import dictionaryFile from '../../../_data/dictionary.json';
import { NotificationService } from '../notification/notification.service';
import { SessionService } from '../session/session.service.js';
import { ConfigurationService } from '../config/configuration.service.js';

@Injectable({
  providedIn: 'root'
})
export class InternationalizationService {
  languages: string[];
  dictionaries: Dictionary[] = dictionaryFile;

  constructor(
    private notif: NotificationService,
    private session: SessionService,
    private config: ConfigurationService
  ) {
    this.languages = this.dictionaries.map(e => e.language);
   }

   public get knownLanguages() {
     return this.languages;
   }

   public translate(key: string): string {
     let lang = this.config.config.defaultLanguage;
     if (this.session.user) {
       lang = this.session.user.language || lang;
     }

     return  this.dictionaries.find(e => e.language === lang).dictionary.find(e => e.key === key).value;
   }
}
