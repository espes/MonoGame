#include <stdio.h>
#include <string.h>

#include <windows.h>

void* (*CreateDecompressionContext)(void);
INT32 (*Decompress)(void* context, char* outBuffer, INT32* outSize, char* inBuffer, INT32* inSize);

int main(int argc, char**argv) {
	
	//Load XnaNative
	HANDLE XnaNative;
	XnaNative = LoadLibrary("XnaNative.dll");
	if (!XnaNative) {
		printf("Please supply a copy of XnaNative.dll\n");
		return -1;
	}
  CreateDecompressionContext = GetProcAddress(XnaNative, "CreateDecompressionContext");
  Decompress = GetProcAddress(XnaNative, "Decompress");
	
	
  if (argc < 3) {
    printf("Usage: %s xnbFile decompressedFile\n", argv[0]);
    return -1;
  }
  FILE* xnbFile = fopen(argv[1], "rb");
  
  BYTE header[3];
  fread(header, sizeof(BYTE), 3, xnbFile);
  if (memcmp(header, "XNB", 3) != 0) return -1;
  
  BYTE platform;
  fread(&platform, sizeof(BYTE), 1, xnbFile);
  printf("Platform: %c\n", platform);
  
  USHORT version;
  fread(&version, sizeof(USHORT), 1, xnbFile);
  
  int graphicsProfile = version & 0x7f00;
  version &= 0x80ff;
  
  BOOL compressed = FALSE;
  if (version == 0x8005) {
    compressed = TRUE;
  } else if (version != 5) {
    printf("Invalid XNB version\n");
    return -1;
  }
  
  INT32 fileSize;
  fread(&fileSize, sizeof(INT32), 1, xnbFile);
  
  if (compressed) {
    INT32 compressedSize = fileSize - 14;
    INT32 decompressedSize;
    fread(&decompressedSize, sizeof(INT32), 1, xnbFile);
    
    FILE* outFile = fopen(argv[2], "wb");
    fwrite(header, sizeof(BYTE), 3, outFile);
    fwrite(&platform, sizeof(BYTE), 1, outFile);
    USHORT outVersion = 5 | graphicsProfile;
    fwrite(&outVersion, sizeof(USHORT), 1, outFile);
    
    //write the decompressedSize as fileSize
    INT32 newFileSize = decompressedSize+10;
    fwrite(&newFileSize, sizeof(INT32), 1, outFile);
    
    void* decompressionContext = CreateDecompressionContext();
    if (decompressionContext == 0) {
      printf("Coudln't create decompression context");
      return -1;
    }
    
    char compressedBuffer[65536];
    char decompressedBuffer[65536];
    
    int compressedPos = 0;
    while (compressedPos < compressedSize) {
      int compressedBufferPos = 0;
      int compressedBufferSize = sizeof(compressedBuffer);
      if (compressedPos+compressedBufferSize > compressedSize) {
        compressedBufferSize = compressedSize-compressedPos;
      }
      fread(compressedBuffer, 1, compressedBufferSize, xnbFile);
      compressedPos += compressedBufferSize;
      compressedBufferPos = 0;
      
      while (1) {
        int inSize = compressedBufferSize - compressedBufferPos;
        int outSize = sizeof(decompressedBuffer);
        int r = Decompress(decompressionContext, decompressedBuffer, &outSize, compressedBuffer+compressedBufferPos, &inSize);
        //printf("%d %d - %d %d - %d %d - %d\n", compressedBufferPos, compressedBufferSize, sizeof(decompressedBuffer), compressedBufferSize - compressedBufferPos, outSize, inSize, r);
        if (r != 0) {
          printf("Decompression error\n");
          return -1;
        }
        compressedBufferPos += inSize;
        if (outSize == 0) break;
        fwrite(decompressedBuffer, 1, outSize, outFile);
      }
    }
    
    fclose(outFile);
  } else {
    printf("Not compressed!\n");
  }
  
  fclose(xnbFile);
  
  return 0;
}
