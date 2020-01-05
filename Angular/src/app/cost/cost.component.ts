import { Component, OnInit } from '@angular/core';
import { CostService } from './cost.service';
import { CostFileName } from '../ViewModel/cost-file-name';
import { GetCostModel } from '../ViewModel/get-cost-model';

@Component({
  selector: 'app-cost',
  templateUrl: './cost.component.html',
  styleUrls: ['./cost.component.scss']
})
export class CostComponent implements OnInit {

  constructor(private costService:CostService) { }

  ngOnInit() {
    this.GetCostData();
  }

  costInfo:GetCostModel[];
  GetCostData(){
    this.costService.GetCostData().subscribe(data=>{
      if(data.code=="0000"){
        this.costInfo=<GetCostModel[]>data.data;
      }
    });
  }

  fileList = [];

  endOpen = false;
  isVisible = false;

  handleCancel(): void {
    this.isVisible = false;
  }

  showModal(): void {
    this.isVisible = true;
  }

  costFileName:CostFileName;
  costType:string;
  costCount:number;
  handleOk():void{
    this.costService.AddCostData(this.costType,this.costCount,this.costFileName).subscribe(data=>{
      if(data.code=="0000"){
        this.GetCostData();
        this.isVisible = false;
      }
    });
  }

  spanValue:number=0;
  upload(event) {
    this.spanValue=1;
    let fileList: FileList = event.target.files;
    //let files: FormData[]=[];
    let formData: FormData = new FormData();
    for (let i = 0; i < fileList.length; i++) {
      let file: File = fileList[i];
      formData.append('uploadFile', file, file.name);
    }
    this.costService.UpLoadingFile(formData).subscribe(response => {
      if (response.code == '0000') {
        this.costFileName=<CostFileName>response.data;
        this.spanValue=2;
      }
    });
  }
}
