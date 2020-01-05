import { Component, OnInit } from '@angular/core';
import { LeaveService } from './leave.service';
import { Leave } from '../ViewModel/leave';

@Component({
  selector: 'app-leave',
  templateUrl: './leave.component.html',
  styleUrls: ['./leave.component.scss']
})
export class LeaveComponent implements OnInit {

  constructor(private leaveService :LeaveService) { }

  isVisible = false;

  listOfData : Leave[];

  ngOnInit() {
    this.GetLeaveData();
  }

  GetLeaveData(){
    this.leaveService.GetLeaveData().subscribe(data=>{
      if(data.code=="0000"){
        this.listOfData=<Leave[]>data.data;
      }      
    });
  }
  showModal(): void {
    this.isVisible = true;
  }

  remark:string;
  selectedValue:string;

  handleOk(): void {
    this.leaveService.AddLeaveData(this.startValue,this.endValue,this.selectedValue,this.remark).subscribe(data=>{
      if(data.code=="0000"){
        this.GetLeaveData();
      }
    });
    this.isVisible=false;
  }

  handleCancel(): void {
    this.isVisible = false;
  }

  startValue: Date | null = null;
  endValue: Date | null = null;
  endOpen = false;

  disabledStartDate = (startValue: Date): boolean => {
    if (!startValue || !this.endValue) {
      return false;
    }
    return startValue.getTime() > this.endValue.getTime();
  };

  disabledEndDate = (endValue: Date): boolean => {
    if (!endValue || !this.startValue) {
      return false;
    }
    return endValue.getTime() <= this.startValue.getTime();
  };

  onStartChange(date: Date): void {
    this.startValue = date;
  }

  onEndChange(date: Date): void {
    this.endValue = date;
  }

  handleStartOpenChange(open: boolean): void {
    if (!open) {
      this.endOpen = true;
    }
  }

  handleEndOpenChange(open: boolean): void {
    this.endOpen = open;
  }
  
}
