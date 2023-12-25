import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Clue } from "../models/clue";

@Injectable({
    providedIn: 'root'
  })

export class ApiService {
    constructor(private http: HttpClient) {
        
    }
    getClue(id: number): Observable<any> {
        return this.http.get<any>(environment.ApiUri + 'odata/Clues(' + id + ')')
          .pipe(map(response => response));
    }
    
    getClueById(id: number): Observable<any> {
      return this.http.get<any>(environment.ApiUri + 'Jeopardy/ById/' + id)
        .pipe(map(response => response));
    }

    getClueByCategoryAndValue(category: string, value: number): Observable<any> {
      return this.http.get<any>(environment.ApiUri + 'Jeopardy/ByCategoryAndValue/' + category + '/' + value)
        .pipe(map(response => response));
    }

    getClueByValue(value: number): Observable<any> {
      return this.http.get<any>(environment.ApiUri + 'Jeopardy/ByValue/' + value)
        .pipe(map(response => response));
    }

    updateClue(id: number, update: Clue): Observable<any> {
      return this.http.patch(environment.ApiUri + 'odata/Clues(' + id + ')', update)
          .pipe(map(response => response));
    }
}