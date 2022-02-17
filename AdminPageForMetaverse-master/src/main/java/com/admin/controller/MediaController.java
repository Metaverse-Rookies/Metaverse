package com.admin.controller;

import com.admin.domain.Media;
import com.admin.repository.MediaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.Banner;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import javax.servlet.http.HttpServletRequest;

@RequestMapping("/media")
@RestController
public class MediaController {
    @Autowired
    MediaRepository mediaRepository;

    @GetMapping("/select")
    public ModelAndView selectAll(){
        ModelAndView mv = new ModelAndView("/media/list");
        mv.addObject("mediaList", mediaRepository.findAll());
        return mv;
    }

    @GetMapping("/select/{no}")
    public ModelAndView selectOne(@PathVariable("no") long mediaNum){
        ModelAndView mv = new ModelAndView("/media/update");
        mv.addObject("media", mediaRepository.findById(mediaNum).orElse(null));
        return mv;
    }

    @GetMapping("/insert")
    public ModelAndView insertForm(){
        ModelAndView mv = new ModelAndView("/media/insert");
        return mv;
    }

    @PostMapping("/insert")
    public RedirectView insert(@ModelAttribute Media media, HttpServletRequest request){
        mediaRepository.save(media);
        return new RedirectView("/media/select");
    }

    @PostMapping("/update/{no}")
    public RedirectView update(@PathVariable("no") long mediaNum,
                               @RequestParam("genre") String genre,
                               @RequestParam("url") String url){
        Media media = mediaRepository.findById(mediaNum).orElse(null);
        if(!media.getGenre().equals(genre))
            media.setGenre(genre);
        if (!media.getUrl().equals(url))
            media.setUrl(url);
        mediaRepository.save(media);
        return new RedirectView("/media/select");
    }

    @PostMapping("/delete/{no}") // DELETE
    public RedirectView deleteOne(@PathVariable("no") long mediaNum){
        mediaRepository.deleteById(mediaNum);
        return new RedirectView("/media/select");
    }
}
