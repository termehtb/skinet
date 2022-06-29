import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CheckoutComponent } from './checkout.component';

const route : Routes = [
  {path: '', component: CheckoutComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(route)
  ],
  exports: [RouterModule]


})
export class CheckoutRoutingModule { }
