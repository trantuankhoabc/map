import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-addresses',
  templateUrl: './addresses.component.html',
  styleUrls: ['./addresses.component.css']
})
export class AddressesComponent implements OnInit {

  public addresses!: Address[] ;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get(environment.baseUrl + "addresses", {
    }).subscribe({
      next: (response) => {
        this.addresses = response as Address[];
      },
      error: (err) => {
        console.error(err)
      },
      complete: () => console.info('Address complete')
    });
  }

}

export interface Address {
  name: string;
  houseName: string;
  city: string;
  state: string;
  pin: number;
}