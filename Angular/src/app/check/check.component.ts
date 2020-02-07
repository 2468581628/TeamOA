import { Component, OnInit } from '@angular/core';
import { CheckModel } from '../ViewModel/check-model';
import { CheckService } from './check.service';
import { CheckLeave } from '../ViewModel/Check/check-leave';
import { CheckOvertime } from '../ViewModel/Check/check-overtime';
import { CheckCost } from '../ViewModel/Check/check-cost';

@Component({
  selector: 'app-check',
  templateUrl: './check.component.html',
  styleUrls: ['./check.component.scss']
})
export class CheckComponent implements OnInit {

  constructor(public checkService:CheckService) { }

  ngOnInit() {
    this.GetLeaveInfo();
    this.GetOvertime();
    this.GetCost();
  }

  tabs = [
    {
      name: '请假',
      icon: 'snippets'
    },
    {
      name: '加班',
      icon: 'tool'
    },
    {
      name: '费用',
      icon: 'red-envelope'
    }
  ];

  tabValue:string="请假";


  tableData:CheckModel={
    costData:null,
    leaveData:null
  };
  recordOrPower(tabValue:string):void{
    this.tabValue=tabValue;
  }

  checkLeaveInfo:CheckLeave[];
  GetLeaveInfo():void{
    this.checkService.GetLeaveInfo().subscribe(data=>{
      if (data.code == '0000') {
        this.checkLeaveInfo=<CheckLeave[]>data.data;
      }
    });
  }

  checkOvertime:CheckOvertime[];
  GetOvertime():void{
    this.checkService.GetOvertimeInfo().subscribe(data=>{
      if (data.code == '0000') {
        this.checkOvertime=<CheckOvertime[]>data.data;
      }
    });
  }

  checkCost:CheckCost[]
  GetCost():void{
    this.checkService.GetCostInfo().subscribe(data=>{
      if (data.code == '0000') {
        this.checkCost=<CheckCost[]>data.data;
      }
    });
  }

  CheckInfo(userId:number,status:string,checkType:number):void{
    this.checkService.CheckInfo(userId,status,checkType).subscribe(data=>{
      if (data.code == '0000') {
        this.GetLeaveInfo();
        this.GetOvertime();
        this.GetCost();
      }
    });
  }
}
