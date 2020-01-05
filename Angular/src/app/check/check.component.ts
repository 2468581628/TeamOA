import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-check',
  templateUrl: './check.component.html',
  styleUrls: ['./check.component.scss']
})
export class CheckComponent implements OnInit {

  constructor() { }

  ngOnInit() {
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

  recordOrPower(tabValue:string):void{
    this.tabValue=tabValue;
  }

  
}
