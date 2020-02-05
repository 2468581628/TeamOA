import { Component, OnInit } from '@angular/core';
import { ArticleWagesService } from './article-wages.service';

@Component({
  selector: 'app-article-wages',
  templateUrl: './article-wages.component.html',
  styleUrls: ['./article-wages.component.scss']
})
export class ArticleWagesComponent implements OnInit {

  constructor(private articleWagesService:ArticleWagesService) { }

  ngOnInit() {
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
      }
    });
  }

}
