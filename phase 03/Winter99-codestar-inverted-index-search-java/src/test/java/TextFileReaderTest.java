import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import java.io.*;
import java.util.HashMap;
import java.util.Map;

import static org.junit.Assert.*;

public class TextFileReaderTest {

    private File testFolder;
    private File emptyFolder;
    private File dataFolder;
    private File simpleFile;

    final Map<Document, String> docsData = new HashMap<>();
    private final Document doc1 = new Document("Doc1");
    private final Document doc2 = new Document("Doc2");
    private final Document doc3 = new Document("Doc3");
    private final Document doc3_ = new Document("Doc3_");
    private final Document doc4 = new Document("Doc4");
    private static final String SIMPLE_TEST_FILE = "mySimpleFile";
    private static final String SIMPLE_CONTENT = "this";


    @Before
    public void setUp() throws IOException {
        docsData.clear();
        docsData.put(doc1,
                "this is simple doc one 1 and also contains some more info about every thing in the worlds");
        docsData.put(doc2,
                "this is simple doc one 2 and have nothing about reality");
        docsData.put(doc3,
                "this is simple doc one 3 and is super imaginary to be used in earth");
        docsData.put(doc3_,
                "this is simple doc one after doc 3 and is super imaginary to be used in earth(But is spam)");
        docsData.put(doc4,
                "how is going these days :>>>>)))");

        testFolder = new File("testDirectory");
        testFolder.mkdirs();
        emptyFolder = new File(testFolder, "EmptyDirectory");
        emptyFolder.mkdirs();
        dataFolder = new File(testFolder, "data");
        dataFolder.mkdirs();
        simpleFile = new File(testFolder, SIMPLE_TEST_FILE);
        writeToFile(simpleFile, SIMPLE_CONTENT);
        for (Map.Entry<Document, String> records : docsData.entrySet()) {
            final File dataFile = new File(dataFolder, records.getKey().getId());
            writeToFile(dataFile, records.getValue());
        }
    }

    public void writeToFile(File file, String content) throws IOException {
        final OutputStreamWriter writer = new OutputStreamWriter(new FileOutputStream(file));
        writer.write(content);
        writer.close();
    }


    @After
    public void tearDown() {
        File[] files = dataFolder.listFiles();
        if (files != null) {
            for (File f : files) {
                f.delete();
            }
        }
        dataFolder.delete();
        emptyFolder.delete();
        simpleFile.delete();
        testFolder.delete();
    }

    @Test
    public void emptyFolderTest() {
        Map<Document, String> result = new TextFileReader(emptyFolder.getPath()).readAllFileInFolder();
        assertEquals(0, result.size());
    }

    @Test
    public void dataFolderTest() {
        Map<Document, String> result = new TextFileReader(this.dataFolder.getPath()).readAllFileInFolder();
        assertEquals(docsData.size(), result.size());
    }

    @Test
    public void notExistingTest() {
        Map<Document, String> result = new TextFileReader("NotExistingDirectory").readAllFileInFolder();
        assertEquals(0, result.size());
    }

    @Test
    public void readTextFileTest() {
        assertEquals(SIMPLE_CONTENT, TextFileReader.readTextFile(simpleFile));
    }
}