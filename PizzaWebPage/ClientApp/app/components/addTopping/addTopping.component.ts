import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'addTopping',
    templateUrl: './addTopping.component.html',
    styleUrls: ['./addTopping.component.css']
})
export class addToppingComponent implements OnInit {

    formData: FormGroup;
    private http: Http;
    private router : Router

    constructor(http: Http, router : Router) {
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

        this.http.post('http://localhost:61606/' + 'api/topping/', this.formData.value).subscribe(result => {
            console.log('saved');
            this.router.navigateByUrl('/topping');
        }, error => console.error(error));
    }
}
