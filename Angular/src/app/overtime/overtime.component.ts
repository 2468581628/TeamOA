import { Component, OnInit } from '@angular/core';
import { OvertimeService } from './overtime.service';
import { OvertimeModel } from '../ViewModel/overtime-model';

@Component({
  selector: 'app-overtime',
  templateUrl: './overtime.component.html',
  styleUrls: ['./overtime.component.scss']
})
export class OvertimeComponent implements OnInit {

  constructor(private overtimeService:OvertimeService) { }

  ngOnInit() {
    this.GetData();
  }

  isVisible = false;
  showModal(): void {
    this.isVisible = true;
  }

  handleOk(): void {
    this.isVisible=false;
    this.overtimeService.AddOvertime(this.starttTime,this.endTime,this.inputValue).subscribe(data=>{
      if(data.code=="0000"){
        this.GetData();
      }
    });
  }

  handleCancel(): void {
    this.isVisible = false;
  }

  starttTime:Date;
  endTime:Date;
  inputValue: string;

  overtimeData:OvertimeModel[];

  GetData():void{
    this.overtimeService.GetData().subscribe(data=>{
      if(data.code="0000"){
        this.overtimeData=<OvertimeModel[]>data.data;
      }
    });
  }
}
