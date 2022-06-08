package Examples.SimpleArrayList;

import Pipeline.*;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Locale;


public class Main {



    public static void main(String args[]) {
        Stage1 stage1 = new Stage1();
        Stage2 stage2 = new Stage2();
        Stage3 stage3 = new Stage3();

        Pipeline<ArrayList<String>> p = new Pipeline(new SimpleOperation());


        ArrayList<String> payload = new ArrayList();

        //generate huruf
        long banyakData = 50;
        for (int i = 0; i < banyakData; i++) {
            RandomString huruf = new RandomString();
            payload.add(huruf.getSatuHuruf());
        }
        System.out.println("array:");
        System.out.println(payload);

        //versi sequential
        long mulaiSeq = System.nanoTime();

        //filter ke upper case
        for (int counter = 0; counter < payload.size(); counter++) {
            String pengganti = payload.get(counter).toUpperCase(Locale.ROOT);
            payload.set(counter, pengganti );
        }

        //filter remove special char
        for (int counter = 0; counter < payload.size(); counter++) {
            String pengganti = payload.get(counter).replaceAll("[^a-zA-Z0-9]", "null");
            payload.set(counter, pengganti );
        }

        //filter remove blank char
        for (int counter = 0; counter < payload.size(); counter++) {
            payload.remove("null" );
        }


        long akhirSeq   = System.nanoTime();
        long totalWaktu = akhirSeq - mulaiSeq;
        System.out.println("Sequential");
        System.out.println(payload);
        System.out.println("Waktu sequential: "+ totalWaktu/1000 + " milisecond");



        try {

            //versi pipeline
            long startTime = System.nanoTime();
            p = p.pipe(stage1).pipe(stage2).pipe(stage3);
            long endTime   = System.nanoTime();
            long totalTime = endTime - startTime;
            System.out.println("Pipeline");
            System.out.println(p.run(payload));
            System.out.println("Waktu pipeline: "+totalTime/1000 + " milisecond");



        } catch (Exception e) {
            System.out.println("ini error");;
        }
    }
}