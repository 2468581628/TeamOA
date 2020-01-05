import { Component, OnInit, AfterViewInit } from '@angular/core';
import {
  faLaughWink, faTachometerAlt, faCog, faWrench, faFolder, faChartArea, faTable, faSearch, faBell, faFileAlt,
  faDonate, faExclamationTriangle, faEnvelope, faUser, faCogs, faList, faSignOutAlt, faBars
} from '@fortawesome/free-solid-svg-icons';
import { AppMessageService } from '../global/service/app-message.service';
import { AuthService } from '../global/guard/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent implements OnInit, AfterViewInit {

// font awesome setup
faLaughWink = faLaughWink;
faTachometerAlt = faTachometerAlt;
faCog = faCog;
faWrench = faWrench;
faFolder = faFolder;
faChartArea = faChartArea;
faTable = faTable;
faSearch = faSearch;
faBell = faBell;
faFileAlt = faFileAlt;
faDonate = faDonate;
faExclamationTriangle = faExclamationTriangle;
faEnvelope = faEnvelope;
faUser = faUser;
faCogs = faCogs;
faList = faList;
faSignOutAlt = faSignOutAlt;
faBars = faBars;


  constructor(
    private appMessageService: AppMessageService,
    private authService:AuthService,
    private router: Router
    ) { }

  ngOnInit() {
  }

  ngAfterViewInit(){
    this.appMessageService.subscribeAppStatu(c => {
      console.log("ShowBusy="+c);
    });
  }

  logout(){
    this.authService.logout();
    this.router.navigate(["/login"]);
  }

}
