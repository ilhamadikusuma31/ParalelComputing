package Examples.SimpleArrayList;

import Pipeline.StageInterface;

import java.util.ArrayList;

public class Stage2 implements StageInterface<ArrayList<String>, ArrayList<String>> {

    public ArrayList run(ArrayList payload) {

        //filter remove special char
        for (int counter = 0; counter < payload.size(); counter++) {
            String pengganti = payload.get(counter).toString().replaceAll("[^a-zA-Z0-9]", "null");
            payload.set(counter, pengganti );
        }

        return payload;
    }
}
