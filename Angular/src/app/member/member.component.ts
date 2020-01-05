import { Component, OnInit } from '@angular/core';
import { MemberService } from './member.service';
import { Member } from '../ViewModel/member';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.scss']
})
export class MemberComponent implements OnInit {

  constructor(private memberservice:MemberService,private message: NzMessageService) { }

  listOfData: Member[];
  isVisible = false;
  isVisiblCMemInfo=false;
  isVisibleCPW=false;
  validateForm: FormGroup;

  mem_id:number;
  mem_name:string;
  mem_pw:string;
  mem_pw2:string;
  mem_account:string;
  mem_tel:string;

  ngOnInit() {
    this.getData();
  }

  getData(){
    this.memberservice.getData().subscribe(data=>{
      if(data.code=="0000"){
        this.listOfData=<Member[]>data.data;
      }      
    });
  }
  handleOk(): void {
    this.memberservice.AddMem(this.mem_name,this.mem_pw,this.mem_account,this.mem_tel).subscribe(data=>{
      if(data.code=="0000"){
        this.isVisible = false;
        this.mem_name=this.mem_pw=this.mem_account=this.mem_tel=null;
        this.getData();
      }
      else{
        this.createMessage(data.message);
      }
    });
  }

  createMessage(message:string): void {
    this.message.create("error", `${message}`);
  }

  handleCancel(): void {
    this.isVisible = false;
  }

  AddMember(): void {
    this.isVisible = true;
  }


  OnOrOff(status:any,id:any){
    this.memberservice.UpdStatusData(status,id).subscribe(data=>{
      if(data.code=="0000"){
        this.getData();
      }
    });
  }

  handleCancelCMemInfo(){
    this.isVisiblCMemInfo=false;
  }

  ChangeMemInfo(id:number,name:string,tel:string){
    this.isVisiblCMemInfo=true;
    this.mem_name=name;
    this.mem_tel=tel;
    this.mem_id=id;
  }

  handleOkCMemInfo(){
    this.memberservice.ChangeMemberInfo(this.mem_id,this.mem_name,this.mem_tel).subscribe(data=>{
      if(data.code=="0000"){
        this.handleCancelCMemInfo();
        this.getData();
        this.mem_name=this.mem_pw=this.mem_account=this.mem_tel=null;
      }
    });
  }

  ChangePW(id:number){
    this.mem_id=id;
    this.isVisibleCPW=true;
  }

  handleCancelCPW(){
    this.isVisibleCPW=false;
  }

  handleOkCPW(){
    //console.log(this.mem_id,this.mem_pw,this.mem_pw2)
    if(this.mem_pw2==this.mem_pw){
      this.memberservice.ChangePassWord(this.mem_id,this.mem_pw).subscribe(data=>{
        if(data.code=="0000"){
          this.handleCancelCPW();
          this.getData();
          this.mem_pw=this.mem_pw2=null;
        }
      });
    }
    else{
      this.message.create("error", "密码与确认密码不一致");
    }
  }
}
