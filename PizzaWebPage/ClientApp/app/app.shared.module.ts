import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { toppingComponent } from './components/Topping/topping.component';
import { productComponent } from './components/Products/product.component';
import { addProductComponent } from './components/addProduct/addProduct.component';
import { addToppingComponent } from './components/addTopping/addTopping.component';
import { toppingPizzaComponent } from './components/toppingPizza/toppingPizza.component'


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,

        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        toppingComponent,
        productComponent,
        addProductComponent,
        addToppingComponent,
        toppingPizzaComponent
    ],
    imports: [
        CommonModule,
        HttpModule,

        ReactiveFormsModule,
        FormsModule,

        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'topping', component: toppingComponent },
            { path: 'product', component: productComponent },
            { path: 'addProduct', component: addProductComponent },
            { path: 'addTopping', component: addToppingComponent },
            { path: 'toppingPizza/:productId', component: toppingPizzaComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
