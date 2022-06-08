package Examples.SimpleArrayList;

import Pipeline.StageInterface;

import java.util.ArrayList;

public class Stage3 implements StageInterface<ArrayList<String>, ArrayList<String>> {

    public ArrayList run(ArrayList payload) {

        //filter remove blank char
        for (int counter = 0; counter < payload.size(); counter++) {
            payload.remove("null" );
        }

        return payload;
    }
}
