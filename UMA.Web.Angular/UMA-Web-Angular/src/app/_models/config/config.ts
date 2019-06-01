import {ApiEndpointConf} from './api-endpoints';
import { PolicyConf } from './policy';
import { NotificationConf } from './notification';

export class Config {
  appTitle: string;
  apiUrl: string;
  defaultLanguage: string;
  apiEndpoints: ApiEndpointConf[];
  policies: PolicyConf[];
  notification: NotificationConf;
}
