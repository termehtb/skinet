import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/Pagination';
import { IProductType } from '../shared/models/productType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:7154/api/';
  constructor(private http : HttpClient) { }
  getProduct(brandId?: number , typeId?: number, sort?: string){
    let params = new HttpParams();

    if(brandId){
      params = params.append('brandId', brandId);
    }
    if(typeId){
      params = params.append('typeId', typeId);
    }
    if(sort){
      params = params.append('sort', sort)
    }
    return this.http.get<IPagination>(this.baseUrl + 'products' , {observe: 'response', params})
    .pipe(map(response => {
      return response.body;
    })
    );
  }
  
  getBrands(){
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getProductType(){
    return this.http.get<IProductType[]>(this.baseUrl + 'products/types');
  }
}
