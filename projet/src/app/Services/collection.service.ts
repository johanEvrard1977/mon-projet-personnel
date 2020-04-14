import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Collection } from '../Models/collection';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic '+window.btoa('jojo:jojo')
  })
}

@Injectable({
  providedIn: 'root'
})
export class CollectionService {

  collectionUrl = 'http://localhost:60504/api/Collection/';  // URL to web api
  private handleError: HandleError;
  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('CollectionService');
  
  }
   /** GET heroes from the server */
   getcollections (): Observable<Collection[]> {
    
    return this.http.get<Collection[]>(this.collectionUrl, httpOptions)
      .pipe(catchError(this.handleError('getcollections', []))
      );
  }

  getcollectionById(id:any): Observable<any> {
    return this.http.get<Collection>(this.collectionUrl +id, httpOptions).pipe(
      retry(3), catchError(this.handleError('getCollectionById')));
  }

  register(collection: Collection) {
    return this.http.post(this.collectionUrl, collection, httpOptions);
  }

  registerIntoCollection(collection: Collection) {
    return this.http.post(this.collectionUrl, collection, httpOptions);
  }

  update(collection: Collection, id:any) {
    return this.http.put(this.collectionUrl+id, collection, httpOptions);
  }

  deleteCollection(id:number){
    return this.http.delete(this.collectionUrl+id, httpOptions)
  }

  deleteVaisseau(idV:number, idC:number){
    console.log(idV, idC);
    //return this.http.delete(this.collectionUrl+"DeleteVaisseau/"+idV+"/"+idC, httpOptions)
  }
  
  deletePilote(idP:number, idC:number){
    console.log(idP, idC);
    //return this.http.delete(this.collectionUrl+"/DeletePilote/"+id, httpOptions)
  }
  
  deleteAmelioration(idA:number, idC:number){
    console.log(idA, idC);
  //return this.http.delete(this.collectionUrl+"/DeleteAmelioration/"+id, httpOptions)
  }
}