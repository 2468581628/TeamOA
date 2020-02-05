import { Component, OnInit } from '@angular/core';
import { ArticleWagesService } from './article-wages.service';
import { ArticleWagesModel } from '../ViewModel/article-wages-model';

@Component({
  selector: 'app-article-wages',
  templateUrl: './article-wages.component.html',
  styleUrls: ['./article-wages.component.scss']
})
export class ArticleWagesComponent implements OnInit {

  constructor(private articleWagesService:ArticleWagesService) { }

  ngOnInit() {
    this.GetInfo();
  }

  spanValue:number;

  upload(event) {
    this.spanValue=1;
    let fileList: FileList = event.target.files;
    //let files: FormData[]=[];
    let formData: FormData = new FormData();
    for (let i = 0; i < fileList.length; i++) {
      let file: File = fileList[i];
      formData.append('uploadFile', file, file.name);
    }
    this.articleWagesService.UpLoadingFile(formData).subscribe(response => {
      if (response.code == '0000') {
        this.spanValue=2;
        this.GetInfo();
      }
    });
  }

  articleWagesModel:ArticleWagesModel[];
  GetInfo(){
    this.articleWagesService.GetInfo().subscribe(data=>{
      if (data.code == '0000') {
        this.articleWagesModel=<ArticleWagesModel[]>data.data;
      }
    });
  }

}
