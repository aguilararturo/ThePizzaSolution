import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'toppingPizza',
    templateUrl: './toppingPizza.component.html',
    styleUrls: ['./toppingPizza.component.css']
})
export class toppingPizzaComponent implements OnInit {
    public toppins: Topping[];
    public pizza: Product;

    private productId: number;
    private route$: Subscription;
    private http: Http;
    constructor(private route: ActivatedRoute, http: Http) {
        this.http = http;
    }

    ngOnInit() {
        this.route$ = this.route.params.subscribe(
            (params: Params) => {
                this.productId = +params['productId'];
            }
        );

        this.http.get('http://localhost:61606/' + 'api/topping/').subscribe(result => {
            var data = result.json();
            if (data) {
                this.toppins = data as Topping[];
                for (let topping of this.toppins) {
                    topping.selected = false;
                }
            }
        }, error => console.error(error));

        this.http.get('http://localhost:61606/' + 'api/pizza/' + this.productId).subscribe(result => {
            var data = result.json();
            if (data) {
                this.pizza = data as Product;
            }
        }, error => console.error(error));
    }
    ngOnDestroy() {
        if (this.route$) this.route$.unsubscribe();
    }

    save(): void {
        console.log('submit', this.pizza);

        if(!this.pizza.ProductToppings){
            this.pizza.ProductToppings = [];
        }

        for (let topping of this.toppins) {
            if (topping.selected) {
                var prod: ProductTopping = {
                    ProductID: this.pizza.id,
                    ToppingId: topping.id,
                };

                this.pizza.ProductToppings.push(prod);
            }
        }

        this.http.put('http://localhost:61606/' + 'api/pizza/'+ this.productId, this.pizza).subscribe(result => {
            console.log('saved');
            location.reload();
        }, error => console.error(error));
    }
}

