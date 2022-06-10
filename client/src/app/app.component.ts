import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './shared/models/Pagination';
import { IProduct } from './shared/models/Products';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  
  title = 'Skinet';
  products: IProduct[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {


      
    this.http.get('https://localhost:7154/api/products').subscribe(
      (response : any) => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
    
    
  }
}
