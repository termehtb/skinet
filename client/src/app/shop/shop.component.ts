import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/Products';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm! : ElementRef;
  products: IProduct[] | undefined;
  brands: IBrand[] = [];
  types: IProductType[] = [];
  shopParams = new ShopParams();
  totalCount: number|undefined;
  
  sortOptions = [
    {name: 'alphabetical' , value: 'name'},
    {name: 'Price: Low to Hight', value: 'priceAsc'},
    {name: 'Price: Hight to Low', value: 'priceDesc'}
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getPRoducts();
    this.getBrands();
    this.getTypes();
  }

  getPRoducts(){
    this.shopService.getProducts(this.shopParams).subscribe(response => {
      this.products = response?.data;
      this.shopParams.pageNumber = response?.pageIndex!;
      this.shopParams.pageSize = response?.pageSize!;
      this.totalCount= response?.count;

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
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getPRoducts();
  }
  onTypeSelected(typeId:number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getPRoducts();
  }

  onSortSelected(sort: string){
    this.shopParams.sort = sort;

    this.getPRoducts();
  }

  onPageChange(event: any){
    if(this.shopParams.pageNumber != event ){
      this.shopParams.pageNumber= event.page;
      this.getPRoducts();
    }
  }

  onSearch(){
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getPRoducts()  
  }

  onReset(){
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getPRoducts();
  }


}
