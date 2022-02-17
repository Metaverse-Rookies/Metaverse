package com.admin.domain;

import lombok.*;

import javax.persistence.*;

@Getter
@Setter
@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "Goods")
public class Product { // db �뀒�씠釉붾챸�� Goods
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "productNum")
    private long productNum;
    private String productName;
    private String modelCode;
    private String tvType; // db�뿉�뒗 tvtype
    public long getProductNum() {
		return productNum;
	}

	public void setProductNum(long productNum) {
		this.productNum = productNum;
	}

	public String getProductName() {
		return productName;
	}

	public void setProductName(String productName) {
		this.productName = productName;
	}

	public String getModelCode() {
		return modelCode;
	}

	public void setModelCode(String modelCode) {
		this.modelCode = modelCode;
	}

	public String getTvType() {
		return tvType;
	}

	public void setTvType(String tvType) {
		this.tvType = tvType;
	}

	public String getSize() {
		return size;
	}

	public void setSize(String size) {
		this.size = size;
	}

	public String getQuality() {
		return quality;
	}

	public void setQuality(String quality) {
		this.quality = quality;
	}

	public String getCompany() {
		return company;
	}

	public void setCompany(String company) {
		this.company = company;
	}

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public String getPrice() {
		return price;
	}

	public void setPrice(String price) {
		this.price = price;
	}

	public String getLink() {
		return link;
	}

	public void setLink(String link) {
		this.link = link;
	}

	private String size;
    private String quality;
    private String company;
    private String image;
    private String price;
    private String link;

    public Product(String productName, String modelCode, String tvType, String size, String quality, String company, String image,
                   String price, String link){
        this.productName = productName;
        this.modelCode = modelCode;
        this.tvType = tvType;
        this.size = size;
        this.quality = quality;
        this.company = company;
        this.image = image;
        this.price = price;
        this.link = link;
    }
    
    public Product() {
    	
    }
}
