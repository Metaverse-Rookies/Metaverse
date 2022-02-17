//package com.admin.controller;
//
//@RequiredArgsConstructor
//@RestController
//public class AwsS3Controller {
//
//    private final S3Service s3Uploader;
//
//    @PostMapping("/Video")
//    public String upload(@RequestParam("images") MultipartFile multipartFile) throws IOException {
//        s3Uploader.upload(multipartFile, "static");
//        return "test";
//    }
//}