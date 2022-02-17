package com.admin.service;

import com.amazonaws.services.s3.AmazonS3Client;
import com.amazonaws.services.s3.model.CannedAccessControlList;
import com.amazonaws.services.s3.model.PutObjectRequest;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Optional;
import java.util.UUID;

@Slf4j
@RequiredArgsConstructor
@Component
public class S3Service {

    private final AmazonS3Client amazonS3Client = new AmazonS3Client();

    @Value("${cloud.aws.s3.bucket}")
    public String bucket;  // S3 ��Ŷ �̸�

    public String upload(MultipartFile multipartFile, String dirName) throws IOException {
        File uploadFile = convert(multipartFile)  // ���� ��ȯ�� �� ������ ����
                .orElseThrow(() -> new IllegalArgumentException("error: MultipartFile -> File convert fail"));

        return upload(uploadFile, dirName);
    }

    // S3�� ���� ���ε��ϱ�
    private String upload(File uploadFile, String dirName) {
        String fileName = dirName + "/" + UUID.randomUUID() + uploadFile.getName();   // S3�� ����� ���� �̸� 
        String uploadImageUrl = putS3(uploadFile, fileName); // s3�� ���ε�
        removeNewFile(uploadFile);
        return uploadImageUrl;
    }

    // S3�� ���ε�
    private String putS3(File uploadFile, String fileName) {
        amazonS3Client.putObject(new PutObjectRequest(bucket, fileName, uploadFile).withCannedAcl(CannedAccessControlList.PublicRead));
        return amazonS3Client.getUrl(bucket, fileName).toString();
    }

    // ���ÿ� ����� �̹��� �����
    private void removeNewFile(File targetFile) {
        if (targetFile.delete()) {
            return;
        }
    }

    // ���ÿ� ���� ���ε� �ϱ�
    private Optional<File> convert(MultipartFile file) throws IOException {
        File convertFile = new File(System.getProperty("user.dir") + "/" + file.getOriginalFilename());
        if (convertFile.createNewFile()) { // �ٷ� ������ ������ ��ο� File�� ������ (��ΰ� �߸��Ǿ��ٸ� ���� �Ұ���)
            try (FileOutputStream fos = new FileOutputStream(convertFile)) { // FileOutputStream �����͸� ���Ͽ� ����Ʈ ��Ʈ������ �����ϱ� ����
                fos.write(file.getBytes());
            }
            return Optional.of(convertFile);
        }

        return Optional.empty();
    }
}