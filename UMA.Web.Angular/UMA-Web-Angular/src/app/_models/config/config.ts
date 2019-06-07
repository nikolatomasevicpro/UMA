import {ApiEndpointConf} from './api-endpoints';
import { PolicyConf } from './policy';
import { NotificationConf } from './notification';
import { NotificationLevel } from '../enums/NotificationLevel.enum';

export class Config {
  appTitle: string;
  apiUrl: string;
  defaultLanguage: string;
  neutralLanguage: string;
  apiEndpoints: ApiEndpointConf[];
  policies: PolicyConf[];
  notification: NotificationConf;
  notificationLevel: NotificationLevel;
}
