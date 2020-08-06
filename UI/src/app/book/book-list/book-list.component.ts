import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatDialogConfig } from '@angular/material';
import { BookModel } from 'src/app/Models/Book/book-model';
import { BookrepositoryService } from 'src/app/services/book/bookrepository.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { BookManageComponent } from '../book-manage/book-manage.component';
import { BookCrudComponent } from '../book-crud/book-crud.component';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  //#region Difinitions
  listData: MatTableDataSource<any>;
  Books: BookModel[];
  //#endregion
  
  //#region Grid Definitions
   displayedColumns: string[] = ['ID', 'Title','Description', 'PageCount', 'PublishDate','Action'];
  //#endregion

  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(private service: BookrepositoryService, private dialog: MatDialog, private notificationService: NotificationService) { }

  ngOnInit() {
    
    this.onRefress();
  }
   onRefress(){
      this.service.refressList().subscribe(res => {
        this.Books=res;
        this.listData= new MatTableDataSource(this.Books);
        this.listData.sort = this.sort;
        this.listData.paginator = this.paginator;
   });
    }
    onCreate() {
      this.service.ViwMode="Create New Book";
      this.service.ViwModeDisabled=false;
      this.service.initializeForm();
      const dialogconf = new MatDialogConfig();
      dialogconf.disableClose = true;
      dialogconf.width = "70%";
      dialogconf.autoFocus = true;
      this.dialog.open(BookCrudComponent, dialogconf).afterClosed().subscribe(result=>{
       
          this.onRefress();
  
      });
    }
    onEdit(Book) {
      this.service.ViwMode="Edit Book";
      this.service.ViwModeDisabled=false;
      this.service.GetBookById(Book.ID).subscribe(res => {
      this.service.form.setValue(res);
      //disabled userid when edit
      const dialogconf = new MatDialogConfig();
      dialogconf.disableClose = true;
      dialogconf.width = "70%";
      dialogconf.autoFocus = true;
      this.dialog.open(BookCrudComponent, dialogconf).afterClosed().subscribe(result=>{
       
        this.onRefress();
  
    });
   });
  }
  onView(Book) {
    this.service.ViwMode="View Book";
    this.service.ViwModeDisabled=true;
    this.service.GetBookById(Book.ID).subscribe(res => {
    this.service.form.setValue(res);
    //disabled userid when edit
    const dialogconf = new MatDialogConfig();
    dialogconf.disableClose = true;
    dialogconf.width = "70%";
    dialogconf.autoFocus = true;
    this.dialog.open(BookCrudComponent, dialogconf).afterClosed().subscribe(result=>{
     
      //this.onRefress();

  });
 });
}
  
  onDelete(id) {
      if (confirm('Are you sure to delete this record ?')) {
        this.service.DeleteBook(id).subscribe(res => {
          this.service.refressList().subscribe(res => {
            this.listData.data = res;
            this.notificationService.warn('!Deleted successfully');
  
          });
  
        });
      }
    }
  }
