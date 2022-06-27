import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
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

  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    const basket_id = localStorage.getItem('basket_id');
    if(basket_id){
      this.basketService.getBasket(basket_id).subscribe(()=>
      {console.log('initialized basket')},
      error => {
        console.log(error);
      });
    }
  }
}
