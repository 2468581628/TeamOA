import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgZorroAntdModule, NZ_I18N, zh_CN } from 'ng-zorro-antd';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeComponent } from './home/home.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';

/** 配置 angular i18n **/
import { registerLocaleData } from '@angular/common';
import zh from '@angular/common/locales/zh';
import { LoginComponent } from './login/login.component';
import { ErrorInterceptor } from './global/http-interceptor/error-interceptor';
import { AppConfigService } from './global/service/app-config.service';
import { ShowLoadingInterceptor } from './global/http-interceptor/show-loading-interceptor';
import { LeaveComponent } from './leave/leave.component';
import { CostComponent } from './cost/cost.component';
import { OvertimeComponent } from './overtime/overtime.component';
import { ArticleWagesComponent } from './article-wages/article-wages.component';
import { MemberComponent } from './member/member.component';
import { CheckComponent } from './check/check.component';
registerLocaleData(zh);

// json AppConfig 
const appInitializerFn = (appConfig: AppConfigService) => {
  return () => {
    return appConfig.loadAppConfig();
  }
};

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MainLayoutComponent,
    LoginComponent,
    LeaveComponent,
    CostComponent,
    OvertimeComponent,
    ArticleWagesComponent,
    MemberComponent,
    CheckComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    /** ng-zorro-antd **/
    NgZorroAntdModule,
    FontAwesomeModule
  ],
  bootstrap: [AppComponent],
  /** ng-zorro-antd 多語系 **/
  providers: [
    { provide: NZ_I18N, useValue: zh_CN },
    { provide: HTTP_INTERCEPTORS, useClass: ShowLoadingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AppConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializerFn,
      multi: true,
      deps: [AppConfigService]
    }
  ]
})
export class AppModule { }
