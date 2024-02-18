import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product-service.service';
import { Product } from '../Model/product.model';
import { Router } from '@angular/router'; 
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products : Product[];
  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit(): void {
    this.getProducts();
  }
  getProducts(): void {
    this.productService.getProducts()
      .subscribe(products => this.products = products);
  }
  deleteProduct(id: number): void {
    this.productService.deleteProduct(id)
      .subscribe(() => {
        this.products = this.products.filter(product => product.id !== id);
      });
  }
  editProduct(id: number): void {
    this.router.navigate(['/products', id, 'edit']); // Navigate to the edit screen with product id
  }

}
