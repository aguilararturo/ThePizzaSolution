import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

@Component({
    selector: 'product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css']
})
export class productComponent {
    public products: Product[];
    private http : Http
    private router: Router;
    constructor(http: Http, router: Router , @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.router = router;
        http.get('http://localhost:61606/' + 'api/pizza/').subscribe(result => {
            var data = result.json();
            if (data) {
                this.products = data as Product[];
                console.log('PROD', this.products);
            }
        }, error => console.error(error));
    }

    deleteProduct(id: number): void {
        this.http.delete('http://localhost:61606/' + 'api/pizza/' + id).subscribe(result => {
                console.log('delete Complete');
                location.reload();
        }, error => console.error(error));
    }
}
