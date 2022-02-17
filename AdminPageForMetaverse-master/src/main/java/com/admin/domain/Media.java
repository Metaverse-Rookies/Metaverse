package com.admin.domain;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "Media")
public class Media {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "mediaNum")
    private long mediaNum;
    private String Genre;
    public long getMediaNum() {
		return mediaNum;
	}

	public void setMediaNum(long mediaNum) {
		this.mediaNum = mediaNum;
	}

	public String getGenre() {
		return Genre;
	}

	public void setGenre(String genre) {
		Genre = genre;
	}

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		this.url = url;
	}

	private String url;

    public Media(String Genre, String url){
        this.Genre = Genre;
        this.url = url;
    }
    
    public Media() {
    	
    }
}
