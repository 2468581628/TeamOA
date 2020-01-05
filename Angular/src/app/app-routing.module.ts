import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './global/guard/auth.guard';
import { CostComponent } from './cost/cost.component';
import { MemberComponent } from './member/member.component';
import { LeaveComponent } from './leave/leave.component';
import { OvertimeComponent } from './overtime/overtime.component';
import { ArticleWagesComponent } from './article-wages/article-wages.component';
import { CheckComponent } from './check/check.component';

const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    canActivateChild:[AuthGuard],
    children: [
      {
        path: '',
        component: HomeComponent
      },
      {
        path: 'cost',
        component: CostComponent//费用
      },
      {
        path: 'member',
        component: MemberComponent//人员
      },
      {
        path: 'leave',
        component: LeaveComponent//请假
      },
      {
        path: 'overtime',
        component: OvertimeComponent//加班
      },
      {
        path: 'articlewages',
        component: ArticleWagesComponent//工资条
      },
      {
        path: 'check',
        component: CheckComponent//审批
      }
    ]
  },
  {
    path: 'login',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
