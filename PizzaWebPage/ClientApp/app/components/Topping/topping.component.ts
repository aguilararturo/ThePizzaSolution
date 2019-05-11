import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'topping',
    templateUrl: './topping.component.html',
    styleUrls: ['./topping.component.css']
})
export class toppingComponent {
    public toppins: Topping[];
    private http: Http;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        http.get('http://localhost:61606/' + 'api/topping/').subscribe(result => {
            var data = result.json();
            if (data) {
                this.toppins = data as Topping[];
            }
        }, error => console.error(error));
    }

    deleteTopping(id: number): void {
        this.http.delete('http://localhost:61606/' + 'api/topping/' + id).subscribe(result => {
            console.log('delete Complete');
            location.reload();
        }, error => console.error(error));
    }
}

