package com.admin.controller;

import com.admin.domain.Product;
import com.admin.repository.ProductRepository;
import net.bytebuddy.matcher.StringMatcher;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import javax.servlet.http.HttpServletRequest;
import java.util.List;

@RequestMapping("/product")
@RestController
public class ProductController {
    @Autowired ProductRepository productRepository;

    @GetMapping("/insert")
    public ModelAndView insertForm(){
        ModelAndView mv = new ModelAndView("/product/insert");
        return mv;
    }

    @PostMapping("/insert")
    public RedirectView insert(@ModelAttribute Product product, HttpServletRequest request){
        productRepository.save(product);
        return new RedirectView("/product/select");
    }

    @GetMapping("/select")
    public ModelAndView selectAll(){
        ModelAndView mv = new ModelAndView("/product/list");
        mv.addObject("productList", productRepository.findAll());
        return mv;
    }

    @GetMapping("/select/{no}")
    public ModelAndView selectOne(@PathVariable("no") long productNum, Model model){
        ModelAndView mv = new ModelAndView("/product/update");
        mv.addObject("product", productRepository.findById(productNum).orElse(null));
        return mv;
    }

    @PostMapping("/update/{no}") // UPDATE
    public RedirectView updateOne(@PathVariable("no") long productNum,
                             @RequestParam("productName") String productName,
                             @RequestParam("modelCode") String modelCode,
                             @RequestParam("tvType") String tvType,
                             @RequestParam("size") String size,
                             @RequestParam("quality") String quality,
                             @RequestParam("company") String company,
                             @RequestParam("image") String image,
                             @RequestParam("price") String price,
                             @RequestParam("link") String link){
        Product product = productRepository.findById(productNum).orElse(null);
        if(!product.getProductName().equals(productName))
            product.setProductName(productName);
        if(!product.getModelCode().equals(modelCode))
            product.setModelCode(modelCode);
        if(!product.getTvType().equals(tvType))
            product.setTvType(tvType);
        if(!product.getSize().equals(size))
            product.setSize(size);
        if(!product.getQuality().equals(quality))
            product.setQuality(quality);
        if(!product.getCompany().equals(company))
            product.setCompany(company);
        if(!product.getImage().equals(image))
            product.setImage(image);
        if(!product.getPrice().equals(price))
            product.setPrice(price);
        if(!product.getLink().equals(link))
            product.setLink(link);
        productRepository.save(product);
        return new RedirectView("/product/select");
    }
/*
    @PostMapping("/update/{no}")
    public RedirectView update(@PathVariable("no") long productNum, @ModelAttribute Product product, HttpServletRequest request) {
        product = productRepository.findById(productNum).
        productRepository.save(product);
        return new RedirectView("/product/select");
    }
*/

    @PostMapping("/delete/{no}") // DELETE
    public RedirectView deleteOne(@PathVariable("no") long productNum){
        productRepository.deleteById(productNum);
        return new RedirectView("/product/select");
    }
}
