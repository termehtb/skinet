import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/Products';
import { IProductType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[] | undefined;
  brands: IBrand[] = [];
  types: IProductType[] = [];
  brandIdSelected:number | undefined;
  typeIdSelected: number |undefined;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getPRoducts();
    this.getBrands();
    this.getTypes();
  }

  getPRoducts(){
    this.shopService.getProduct(this.brandIdSelected, this.typeIdSelected).subscribe(response => {
      this.products = response?.data;
   }, error => {
     console.log(error);
   });
  }

  getBrands(){
    this.shopService.getBrands().subscribe(response => {
      this.brands = [{id: 0, name: 'All'}, ...response];
    },error => {
      console.log(error);
    }
    );
  }

  getTypes(){
    this.shopService.getProductType().subscribe(response => {
      this.types = [{id: 0, name: 'All'}, ...response];
    },error => {
      console.log(error);
    }
    )
  }

  onBrandSelected(brandId:number){
    this.brandIdSelected = brandId;
    this.getPRoducts();
  }
  onTypeSelected(typeId:number){
    this.typeIdSelected = typeId;
    this.getPRoducts();
  }


}
