import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'addProduct',
    templateUrl: './addProduct.component.html',
    styleUrls: ['./addProduct.component.css']
})
export class addProductComponent implements OnInit {

    formData: FormGroup;
    private http: Http;
    private router: Router;

    constructor(http: Http,  router: Router) {
        this.http = http;
        this.router = router;
    }

    ngOnInit() {
        this.formData = new FormGroup({
            name: new FormControl('')
        });
    }
    onSubmit(): void {
        console.log('submit', this.formData.value);

        this.http.post('http://localhost:61606/' + 'api/pizza/', this.formData.value).subscribe(result => {
            console.log('saved');
            this.router.navigateByUrl('/product');
        }, error => console.error(error));
    }
}

