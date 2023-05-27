import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, lastValueFrom, of } from 'rxjs';
import { Guid } from 'src/app/models/database/GUID';
import { LoggedData } from 'src/app/models/database/LoggedData';

@Injectable({
  providedIn: 'root'
})
export class DatabaseLoggerService {
  private errorData: LoggedData;

  constructor(private http: HttpClient) {
    this.errorData = {log_Id:Guid, data:"error", acc_Id:Guid, account:null};
  }

  public async GetAll() {
    return await lastValueFrom(this.http.get<LoggedData[]>('http://localhost:5274/api/log'));
  }

  public async GetById(id:string) {
    return this.http.get<LoggedData>('http://localhost:5274/api/log/getById?id='+id).pipe(
      catchError(() => {return of(this.errorData)
    }));
  }

  public async GetByAccountId(acc_id:string) {
    return await lastValueFrom(this.http.get<LoggedData[]>('http://localhost:5274/api/log/getByAccountId?id=' + acc_id));
  }

  public async Create(data:string, acc_id:string) {
    let loggedData: LoggedData = {log_Id:Guid, data:data, acc_Id:acc_id, account:null}
    await this.http.post('http://localhost:5274/api/log/create', loggedData).subscribe(response => {
      console.log(response)
    });
  }

  public async Delete(id:string) {
    await this.http.delete('http://localhost:5274/api/log/delete?id=' + id).subscribe(response => {
      console.log(response)
    });
  }
}
