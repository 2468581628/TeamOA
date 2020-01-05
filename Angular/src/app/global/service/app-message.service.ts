import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppMessageService {

  constructor() { }

  private _busyCount = new BehaviorSubject(0);

  public appBusy() {
    this._busyCount.next(this._busyCount.getValue() + 1);
  }

  public appIdle() {
    let v = this._busyCount.getValue() - 1;
    if (v < 0) {
      v = 0;
    }
    this._busyCount.next(v);
  }

  subscribeAppStatu(f: (v: boolean) => void) {
    this._busyCount.subscribe(v => f(v > 0));
  }

  unSubscribeAppStatu() {
    this._busyCount.unsubscribe();
  }
}
