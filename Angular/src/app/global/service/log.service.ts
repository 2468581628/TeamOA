import { Injectable } from '@angular/core';
import { LogType } from '../model/log-model';
@Injectable({
  providedIn: 'root'
})
export class LogService {

  constructor() { }

  log(type: LogType, message: string) {
    console.log(`log service: [${type}] ${message}`);
  }
}
