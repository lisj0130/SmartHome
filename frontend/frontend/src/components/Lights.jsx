export default function Lights({ lampStates }) {
    return (
        <>
            {/* Ljuskällor */}
            <ambientLight intensity={1} /> {/* Mjuk ljuskälla */}

            <pointLight // Taklampa, id = 1
                color="#fff8dc"             // varmvit färg
                intensity={lampStates[1] ? 30 : 0}               // starkt ljus
                position={[0, 2, 0]}        // takposition i mitten av rummet
                distance={60}               // hur långt ljuset når
                decay={1.5}                   // realistiskt ljusavtagande
                castShadow
            />

            <pointLight // golvlampa, id = 2
                color="white"       // mjukt varmt ljus, du kan också använda hex t.ex. "#ffdca3"
                intensity={lampStates[2] ? 10 : 0}           // styrka på ljuset
                position={[-8.8, 3.2, -8.5]} // placera lite ovanför lampans bas
                distance={15}           // hur långt ljuset når
                decay={1.5}               // ljusets avtagande (2 = realistiskt)
            />

            <pointLight  // dekorationslampa, id = 3
                color="white"       // mjukt varmt ljus, du kan också använda hex t.ex. "#ffdca3"
                intensity={lampStates[3] ? 5 : 0}           // styrka på ljuset
                position={[9, 2, 5]} // placera lite ovanför lampans bas
                distance={15}           // hur långt ljuset når
                decay={1.5}               // ljusets avtagande (2 = realistiskt)
            />
        </>
    );
}
