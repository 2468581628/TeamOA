import { Injectable, Injector } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {
  private appConfig: ConfigModel;
  constructor(private injector: Injector) { }

  loadAppConfig() {
    let http = this.injector.get(HttpClient);

    return http.get<ConfigModel>(environment.appConfigPath)
      .toPromise()
      .then(data => {
        this.appConfig = data;
      })
      .catch(error => {
        console.warn("Error loading app-config.json, using envrionment file instead");
        this.appConfig = {
          webapiUrl:"localhost"
        };
      })
  }

  get config() {
    return this.appConfig;
  }
}

export interface ConfigModel {
  webapiUrl: string;
}