import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToolsService {

  constructor() { }

  dateFromISO8601(isostr) {
    const parts = isostr.match(/\d+/g);
    const resDate = new Date(Date.UTC(parts[0], parts[1] - 1, parts[2], parts[3], parts[4], parts[5]));
    return resDate;
  }

  ticksFromISO8601(isostr) {
    const parts = isostr.match(/\d+/g);
    const resDate = Date.UTC(parts[0], parts[1] - 1, parts[2], parts[3], parts[4], parts[5]);
    return resDate;
  }
}
