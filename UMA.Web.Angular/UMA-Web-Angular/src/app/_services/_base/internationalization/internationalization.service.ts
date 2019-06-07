import { Injectable, OnInit } from '@angular/core';
import { Dictionary } from 'src/app/_models/internationalization/Dictionary';
import dictionaryFile from '../../../_data/dictionary.json';
import { SessionService } from '../session/session.service.js';
import { ConfigurationService } from '../config/configuration.service.js';
import { BehaviorSubject, Observable } from 'rxjs';
import { NotificationService } from '../notification/notification.service.js';
import { Culture } from 'src/app/_models/internationalization/Culture.js';

@Injectable({
  providedIn: 'root'
})
export class InternationalizationService implements OnInit {
  cultures: Culture[];
  dictionaries: Dictionary[] = dictionaryFile;

  private languageSubject: BehaviorSubject<string> = new BehaviorSubject<string>(this.config.config.defaultLanguage);
  public language: Observable<string> = this.languageSubject.asObservable();

  constructor(
    private session: SessionService,
    private config: ConfigurationService,
    private notif: NotificationService
  ) {
    this.cultures = this.dictionaries.map(e => {
      const culture = { name: e.language, nativeName: e.nativeName} as Culture;
      return culture;
    });

    this.session.currentProfile.subscribe(profile => {
      if (profile) {
        this.switchLanguage(profile.locale);
      } else {
        this.switchLanguage(this.config.config.defaultLanguage);
      }
    });
  }

  ngOnInit() {
  }

  public switchLanguage(language: string) {
    if (language) {
      this.languageSubject.next(language);
      this.notif.info(this.translate('Info_Language_Switch', [this.languageSubject.value]), 'International :');
    }
  }

  public get knownLanguages() {
    return this.cultures;
  }

  public translate(key: string, values?: string[]): string {
    let result = '';
    let lang = this.config.config.defaultLanguage;

    if (!!this.languageSubject) {
      lang = this.languageSubject.value || lang;
    }

    result = this.findTranslation(key, lang);
    if (!result) {
      result = this.findTranslation(key, this.config.config.neutralLanguage);
    }

    if (!!result && values && values.length > 0) {
      for (let index = 0; index < values.length; index++) {
        result = result.replace('{' + index + '}', values[index]);
      }
    }

    return result;
  }

  private findTranslation(key: string, language: string) {
    let result = '';

    const lang = this.dictionaries.find(e => e.language === language);
    if (lang) {
      const pair = lang.dictionary.find(e => e.key === key);
      if (pair) {
        result = pair.value;
      }
    }

    return result;
  }
}
