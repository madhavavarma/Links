import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Link } from './links.model';
import { groupBy } from './app.utils';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Links';
  objectKeys = Object.keys;
  linkByCategory: { [key : string] : Link[] };

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getLinks();
  }

  getLinks() {
    return this.http.get('assets/data/links.json').subscribe(links => {
      this.linkByCategory = groupBy(links, 'category');
    });
  }
}
