import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime, switchMap, distinctUntilChanged } from 'rxjs/operators'
import { GithubapiService } from '../services/githubapi.service'
import { Repository } from '../interfaces/repository'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent  implements OnInit{

  title = 'GitHub API Showcase';
  private searchTerms = new Subject<string>();
  repositories!: Repository[];
  page: number = 1;
  perPage: number = 30;

  constructor(private githubapiservice: GithubapiService) {}

  ngOnInit(): void {
    this.searchTerms.pipe(
      debounceTime(1000),
      distinctUntilChanged(),
      switchMap(term => (console.log('Term: ' + term), this.githubapiservice.searchRepositories(term, this.page, this.perPage)))
    )
    .subscribe(data => this.repositories = this.repositories = data.item.repositories);
  }

  getValue(event: Event): string {
    return (event.target as HTMLInputElement).value;
  }

  search(term: string) 
  {
    this.searchTerms.next(term);
  }
}