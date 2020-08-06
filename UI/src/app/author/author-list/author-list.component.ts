import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { AuthorModel } from 'src/app/Models/Author/author-model';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { AuthorRepositoryService } from 'src/app/services/author/author-repository.service';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})
export class AuthorListComponent implements OnInit {
  //#region Difinitions
  listData: MatTableDataSource<any>;
  Books: AuthorModel[];
  //#endregion
  
  //#region Grid Definitions
  displayedColumns: string[] = ['ID', 'FirstName','LastName'];
//#endregion
@ViewChild(MatSort, { static: false }) sort: MatSort;
@ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;  
constructor(private service:AuthorRepositoryService) { }
  @Input () BookId:number
  ngOnInit() {
    this.onRefress();
  }

  onRefress(){
   this.service.refressList(this.BookId).subscribe(res => {
     this.Books=res;
      this.listData= new MatTableDataSource(this.Books);
      this.listData.sort = this.sort;
      this.listData.paginator = this.paginator;
 });
  }

}
